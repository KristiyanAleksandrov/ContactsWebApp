import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { createReducer, on } from '@ngrx/store';
import { Contact } from '../models/contact.model';
import { loadContactsSuccess, addContactSuccess } from './contact.actions';

export interface ContactState extends EntityState<Contact> {
  loaded: boolean;
}

export const adapter = createEntityAdapter<Contact>();

export const initialState: ContactState = adapter.getInitialState({
  loaded: false,
});

export const contactReducer = createReducer(
  initialState,
  on(loadContactsSuccess, (state, { contacts }) =>
    adapter.setAll(contacts, { ...state, loaded: true })
  ),
  on(addContactSuccess, (state, { contact }) =>
    adapter.addOne(contact, state)
  )
);