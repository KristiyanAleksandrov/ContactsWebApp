import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Contact } from '../../models/contact.model';
import { addContact } from '../../store/contact.actions';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { CalendarModule } from 'primeng/calendar';
import { DialogModule } from 'primeng/dialog';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-contact-form',
  standalone: true,
  imports: [
    ButtonModule,
    InputTextModule,
    CalendarModule,
    DialogModule,
    ReactiveFormsModule,
  ],
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.scss'],
})
export class ContactFormComponent {
  displayDialog = false; // Initialize the dialog visibility
  contactForm: FormGroup;

  constructor(private fb: FormBuilder, private store: Store) {
    this.contactForm = this.fb.group({
      firstName: ['', Validators.required],
      surname: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      address: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      iban: ['', Validators.required],
    });
  }

  showDialog() {
    this.displayDialog = true; // Show the dialog
  }

  onSubmit() {
    if (this.contactForm.valid) {
      const contact: Contact = this.contactForm.value;
      this.store.dispatch(addContact({ contact }));
      this.displayDialog = false; // Hide the dialog after submission
      this.contactForm.reset(); // Reset the form
    }
  }
}