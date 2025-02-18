import { Component, OnInit } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Contact } from '../../models/contact.model';
import { deleteContact, loadContacts } from '../../store/contact.actions';
import { selectAllContacts } from '../../store/contact.selectors';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [
    ButtonModule,
    CommonModule,
    TableModule, 
    DatePipe,   
  ],
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.scss'],
})
export class ContactListComponent implements OnInit {
  contacts$: Observable<Contact[]>;

  constructor(private store: Store) {
    this.contacts$ = this.store.select(selectAllContacts);
  }

  deleteContact(id: string): void {
    if (confirm('Are you sure you want to delete this contact?')) {
      this.store.dispatch(deleteContact({ id }));
    }
  }

  ngOnInit(): void {
    this.store.dispatch(loadContacts());
  }
}