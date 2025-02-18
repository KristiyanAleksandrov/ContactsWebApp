import { createAction, props } from '@ngrx/store';
import { Contact } from '../models/contact.model';

export const loadContacts = createAction('[Contact] Load Contacts');
export const loadContactsSuccess = createAction(
  '[Contact] Load Contacts Success',
  props<{ contacts: Contact[] }>()
);
export const loadContactsFailure = createAction(
  '[Contact] Load Contacts Failure',
  props<{ error: string }>()
);

export const addContact = createAction(
  '[Contact] Add Contact',
  props<{ contact: Contact }>()
);
export const addContactSuccess = createAction(
  '[Contact] Add Contact Success',
  props<{ contact: Contact }>()
);
export const addContactFailure = createAction(
  '[Contact] Add Contact Failure',
  props<{ error: string }>()
);

export const deleteContact = createAction(
  '[Contact] Delete Contact',
  props<{ id: string }>()
);

export const deleteContactSuccess = createAction(
  '[Contact] Delete Contact Success',
  props<{ id: string }>()
);

export const deleteContactFailure = createAction(
  '[Contact] Delete Contact Failure',
  props<{ error: string }>()
);

export const clearError = createAction('[Contact] Clear Error');