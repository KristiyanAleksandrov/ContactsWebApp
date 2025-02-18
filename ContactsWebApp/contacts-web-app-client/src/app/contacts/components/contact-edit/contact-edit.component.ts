import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Contact } from '../../models/contact.model';
import { editContact } from '../../store/contact.actions';

@Component({
  selector: 'app-contact-edit',
  templateUrl: './contact-edit.component.html',
  styleUrls: ['./contact-edit.component.scss']
})
export class ContactEditComponent implements OnInit {
  @Input() contact!: Contact;
  editForm!: FormGroup;
  displayDialog = false;

  constructor(private fb: FormBuilder, private store: Store) {}

  ngOnInit() {
    this.editForm = this.fb.group({
      firstName: [this.contact.firstName, Validators.required],
      surname: [this.contact.surname, Validators.required],
      dateOfBirth: [this.contact.dateOfBirth, Validators.required],
      address: [this.contact.address, Validators.required],
      phoneNumber: [this.contact.phoneNumber, Validators.required],
      iban: [this.contact.iban, Validators.required],
    });

    this.displayDialog = true;
  }

  onSubmit() {
    if (this.editForm.valid) {
      const updatedContact = { ...this.contact, ...this.editForm.value };
      this.store.dispatch(editContact({ contact: updatedContact }));
      this.displayDialog = false;
    }
  }
}
