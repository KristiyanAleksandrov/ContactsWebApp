import { createFeatureSelector, createSelector } from '@ngrx/store';
import { ContactState, adapter } from './contact.reducer';

export const selectContactState = createFeatureSelector<ContactState>('contact');

export const { selectAll } = adapter.getSelectors();

export const selectAllContacts = createSelector(
  selectContactState,
  (state) => selectAll(state)
);

export const selectContactError = createSelector(
    selectContactState,
    (state: ContactState) => state.error
  );