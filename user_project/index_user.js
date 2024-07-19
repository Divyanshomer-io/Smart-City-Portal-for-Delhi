const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors'); // Import CORS middleware
const swaggerJsdoc = require('swagger-jsdoc');
const swaggerUi = require('swagger-ui-express');
const moment = require('moment-timezone'); // Import moment-timezone

const app = express();
const port = 7102;

// Middleware
app.use(cors()); // Enable CORS for all routes
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));

// Example data (replace with your actual data source)
let userlists = [];
// Swagger options
const swaggerOptions = {
  swaggerDefinition: {
    openapi: '3.0.0',
    info: {
      title: 'Simple API with Swagger',
      version: '1.0.0',
      description: 'A simple API with Swagger integration'
    },
  },
  apis: ['index_user.js'], // Specify the file path where your API routes are defined
};

const swaggerSpec = swaggerJsdoc(swaggerOptions);

// Serve Swagger UI
app.use('/api-docs', swaggerUi.serve, swaggerUi.setup(swaggerSpec));

/**
 * @swagger
 * /api/userlists:
 *   get:
 *     summary: Returns a list of userlists
 *     description: Returns a list of userlists from the database
 *     responses:
 *       '200':
 *         description: A JSON array of userlists
 *         content:
 *           application/json:
 *             schema:
 *               type: array
 *               items:
 *                 type: object
 *                 properties:
 *                   Id:
 *                     type: integer
 *                   Username:
 *                     type: string
 *                   PasswordHash:
 *                     type: string
 *                   Email:
 *                     type: string
 *                   LastLoginTime:
 *                     type: string
 *                     format: date-time
 *                   CreatedAt:
 *                     type: string
 *                     format: date-time
 *                   UpdatedAt:
 *                     type: string
 *                     format: date-time
 *   post:
 *     summary: Add or update a user in the userlists
 *     description: Add a new user or update existing user in the userlists array
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             type: object
 *             properties:
 *               Id:
 *                 type: integer
 *               Username:
 *                 type: string
 *               PasswordHash:
 *                 type: string
 *               Email:
 *                 type: string
 *     responses:
 *       '200':
 *         description: Successfully added or updated the user
 *       '400':
 *         description: Invalid request body
 */
app.post('/api/userlists', (req, res) => {
  const { Id, Username, PasswordHash, Email } = req.body;
  if (!Id || !Username || !PasswordHash || !Email) {
    return res.status(400).send('Invalid request body');
  }

  // Check if a user with the same Id already exists
  const existingUserIndex = userlists.findIndex(user => user.Id === Id);

  // Get current time in IST
  const currentTime = moment().tz('Asia/Kolkata').format(); // Convert to ISO string in IST

  if (existingUserIndex !== -1) {
    // User with the same Id found
    const existingUser = userlists[existingUserIndex];
    
    // Check if Username, PasswordHash, or Email has changed
    if (existingUser.Username !== Username || existingUser.PasswordHash !== PasswordHash || existingUser.Email !== Email) {
      // Update Username, PasswordHash, Email, and UpdatedAt
      existingUser.Username = Username;
      existingUser.PasswordHash = PasswordHash;
      existingUser.Email = Email;
      existingUser.UpdatedAt = currentTime;
    }

    // Always update LastLoginTime
    existingUser.LastLoginTime = currentTime;

    res.status(200).json(existingUser);
  } else {
    // User does not exist, create a new user with the current time as CreatedAt and LastLoginTime
    const newUser = {
      Id,
      Username,
      PasswordHash,
      Email,
      LastLoginTime: currentTime,
      CreatedAt: currentTime,
      UpdatedAt: currentTime
    };

    userlists.push(newUser);
    res.status(200).json(newUser);
  }
});

// Endpoint to get all userlists
app.get('/api/userlists', (req, res) => {
  res.json(userlists);
});

// Root route handler
app.get('/', (req, res) => {
  res.send('Welcome to my API!'); // Example response
});

// Start the server
app.listen(port, () => {
  console.log(`Server is running at http://localhost:${port}`);
});
