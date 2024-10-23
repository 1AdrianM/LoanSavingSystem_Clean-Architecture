// faq.component.ts
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

interface FAQItem {
  question: string;
  answer: string;
  isOpen: boolean;
}

@Component({
  selector: 'app-faq',
  standalone: true,
  imports: [CommonModule], // Import CommonModule here

  templateUrl: './faq.component.html',
  styleUrls: ['./faq.component.css']
})
export class FAQComponent {
  faqs: FAQItem[] = [
    { 
      question: 'What types of hosting plans do you offer?', 
      answer: 'We offer shared hosting, VPS hosting, dedicated server hosting, and cloud hosting plans.', 
      isOpen: false 
    },
    { 
      question: 'What is the uptime guarantee for your hosting services?', 
      answer: 'We guarantee an uptime of 99.9% for all our hosting services.', 
      isOpen: false 
    },
    { 
      question: 'Do you provide website migration assistance?', 
      answer: 'Yes, we offer free website migration assistance for new customers.', 
      isOpen: false 
    },
    { 
      question: 'What security measures do you have in place?', 
      answer: 'We employ advanced security measures including firewalls, DDoS protection, and regular security audits.', 
      isOpen: false 
    }
  ];


  toggleAnswer(faq: FAQItem): void {
    faq.isOpen = !faq.isOpen; // Toggle the isOpen property
  }
}
