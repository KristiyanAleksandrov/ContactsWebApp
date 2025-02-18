import { createAction, props } from '@ngrx/store';
import { Contact } from '../models/contact.model';

export const loadContacts = createAction('[Contact] Load Contacts');
export const loadContactsSuccess = createAction(
  '[Contact] Load Contacts Success',
  props<{ contacts: Contact[] }>()
);

export const addContact = createAction(
  '[Contact] Add Contact',
  props<{ contact: Contact }>()
);
export const addContactSuccess = createAction(
  '[Contact] Add Contact Success',
  props<{ contact: Contact }>()
);