import { Component, OnInit } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Contact } from '../../models/contact.model';
import { loadContacts } from '../../store/contact.actions';
import { selectAllContacts } from '../../store/contact.selectors';
import { TableModule } from 'primeng/table';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [
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

  ngOnInit(): void {
    this.store.dispatch(loadContacts());
  }
}