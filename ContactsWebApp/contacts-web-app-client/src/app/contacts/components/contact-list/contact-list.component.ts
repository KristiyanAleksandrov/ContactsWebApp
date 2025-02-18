import { Component, OnInit } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Contact } from '../../models/contact.model';
import { deleteContact, editContact, loadContacts } from '../../store/contact.actions';
import { selectAllContacts } from '../../store/contact.selectors';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { CalendarModule } from 'primeng/calendar';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [
    ButtonModule,
    CommonModule,
    TableModule, 
    DatePipe, 
    DialogModule,
    InputTextModule,
    CalendarModule,
    DialogModule,
    ReactiveFormsModule,
  ],
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.scss'],
})
export class ContactListComponent implements OnInit {
  contacts$: Observable<Contact[]>;
  selectedContact: Contact | null = null;
  displayEditDialog = false;
  editForm!: FormGroup;

  constructor(private fb: FormBuilder, private store: Store) {
    this.contacts$ = this.store.select(selectAllContacts);
  }

  deleteContact(id: string): void {
    if (confirm('Are you sure you want to delete this contact?')) {
      this.store.dispatch(deleteContact({ id }));
    }
  }

  editContact(contact: Contact) {
    this.selectedContact = { ...contact };
    this.displayEditDialog = true;
    this.editForm = this.fb.group({
      firstName: [contact.firstName, Validators.required],
      surname: [contact.surname, Validators.required],
      dateOfBirth: [contact.dateOfBirth ? new Date(contact.dateOfBirth) : null, Validators.required],
      address: [contact.address, Validators.required],
      phoneNumber: [contact.phoneNumber, Validators.required],
      iban: [contact.iban, Validators.required],
    });
  }

  onEdit() {
    if (this.editForm.valid && this.selectedContact) {
      const updatedContact = { ...this.selectedContact, ...this.editForm.value };
      this.store.dispatch(editContact({ contact: updatedContact }));
      this.displayEditDialog = false;
      this.selectedContact = null;
    }
  }

  ngOnInit(): void {
    this.store.dispatch(loadContacts());
  }
}