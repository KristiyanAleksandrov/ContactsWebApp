import { Component } from '@angular/core';
import { ContactListComponent } from './contacts/components/contact-list/contact-list.component';
import { ContactFormComponent } from './contacts/components/contact-form/contact-form.component';
import { ToastModule } from 'primeng/toast'; 

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ContactListComponent, ContactFormComponent, ToastModule],
  templateUrl: './app.component.html',
  styles: [
    `
      .container {
        max-width: 1200px;
        margin: 0 auto;
        padding: 20px;
      }

      h1 {
        text-align: center;
        margin-bottom: 20px;
      }
    `,
  ],
})
export class AppComponent {}