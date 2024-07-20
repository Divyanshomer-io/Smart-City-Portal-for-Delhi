import { Component, HostListener, ElementRef } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  private searchForm!: HTMLElement | null;
  private loginForm!: HTMLElement | null;

  constructor(private elementRef: ElementRef) {}

  ngOnInit(): void {
    this.searchForm = this.elementRef.nativeElement.querySelector('.search-form');
    this.loginForm = this.elementRef.nativeElement.querySelector('.login-form-container');
    this.setupEventListeners();
    this.toggleHeaderClass();
  }

  private setupEventListeners(): void {
    if (this.searchForm) {
      this.elementRef.nativeElement.querySelector('#search-btn')?.addEventListener('click', () => {
        this.searchForm!.classList.toggle('active');
      });
    }

    if (this.loginForm) {
      this.elementRef.nativeElement.querySelector('#login-btn')?.addEventListener('click', () => {
        this.loginForm!.classList.toggle('active');
      });

      this.elementRef.nativeElement.querySelector('#close-login-btn')?.addEventListener('click', () => {
        this.loginForm!.classList.remove('active');
      });
    }
  }

  @HostListener('window:scroll', ['$event'])
  onWindowScroll(): void {
    this.toggleHeaderClass();
    if (this.searchForm) {
      this.searchForm.classList.remove('active');
    }
  }

  private toggleHeaderClass(): void {
    const header2 = document.querySelector('.header .header-2');
    if (header2) {
      if (window.scrollY > 80) {
        header2.classList.add('active');
      } else {
        header2.classList.remove('active');
      }
    }
  }

}


