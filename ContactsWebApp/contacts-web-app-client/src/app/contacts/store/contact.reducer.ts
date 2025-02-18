import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { createReducer, on } from '@ngrx/store';
import { Contact } from '../models/contact.model';
import {
  loadContactsSuccess,
  loadContactsFailure,
  addContactSuccess,
  addContactFailure,
  clearError,
  deleteContactSuccess
} from './contact.actions';

export interface ContactState extends EntityState<Contact> {
  loaded: boolean;
  error: string | null;
}

export const adapter = createEntityAdapter<Contact>();

export const initialState: ContactState = adapter.getInitialState({
  loaded: false,
  error: null,
});

export const contactReducer = createReducer(
  initialState,
  on(loadContactsSuccess, (state, { contacts }) =>
    adapter.setAll(contacts, { ...state, loaded: true, error: null })
  ),
  on(loadContactsFailure, (state, { error }) => ({
    ...state,
    loaded: false,
    error,
  })),
  on(addContactSuccess, (state, { contact }) =>
    adapter.addOne(contact, { ...state, error: null })
  ),
  on(deleteContactSuccess, (state, { id }) =>
    adapter.removeOne(id, state)
  ),
  on(clearError, (state) => ({ ...state, error: null })),
  on(addContactFailure, (state, { error }) => ({
    ...state,
    error,
  }))
  
);