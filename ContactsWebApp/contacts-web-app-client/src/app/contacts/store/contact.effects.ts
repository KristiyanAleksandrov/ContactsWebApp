import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, mergeMap, tap } from 'rxjs/operators';
import { ContactService } from '../services/contact.service';
import {
  loadContacts,
  loadContactsSuccess,
  addContact,
  addContactSuccess,
  addContactFailure,
  deleteContact,
  deleteContactSuccess,
  deleteContactFailure,
} from './contact.actions';
import { MessageService } from 'primeng/api';

@Injectable()
export class ContactEffects {
  loadContacts$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadContacts),
      mergeMap(() =>
        this.contactService.getContacts().pipe(
          map((contacts) => loadContactsSuccess({ contacts })),
          catchError(() => of({ type: '[Contact] Load Contacts Failed' }))
        )
      )
    )
  );

  deleteContact$ = createEffect(() =>
    this.actions$.pipe(
      ofType(deleteContact),
      mergeMap(({ id }) =>
        this.contactService.deleteContact(id).pipe(
          map(() => {
            this.messageService.add({
              severity: 'success',
              summary: 'Deleted',
              detail: 'Contact deleted successfully!',
            });
            return deleteContactSuccess({ id });
          }),
          mergeMap(() => of(loadContacts())),
          catchError((error) => {
            return of(deleteContactFailure({ error: error.message }));
          })
        )
      )
    )
  );

  addContact$ = createEffect(() =>
    this.actions$.pipe(
      ofType(addContact),
      mergeMap(({ contact }) =>
        this.contactService.addContact(contact).pipe(
          map((newContact) => addContactSuccess({ contact: newContact })),
          tap(() => {
            this.messageService.add({
              severity: 'success',
              summary: 'Success',
              detail: 'Contact added successfully!',
            });
          }),
          mergeMap(() => of(loadContacts())),
          catchError((error) => {
            const errorMessages = error?.error?.errors
              ? Object.values(error.error.errors).flat()
              : ['Failed to add contact. Please try again.'];

            const errorMessage = errorMessages.join(', ');

            return of(addContactFailure({ error: errorMessage }));
          })
        )
      )
    )
  );

  constructor(
    private actions$: Actions,
    private contactService: ContactService,
    private messageService: MessageService
  ) {}
}
