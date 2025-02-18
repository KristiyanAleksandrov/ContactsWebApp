import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, mergeMap } from 'rxjs/operators';
import { ContactService } from '../services/contact.service';
import {
  loadContacts,
  loadContactsSuccess,
  addContact,
  addContactSuccess,
} from './contact.actions';

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

  addContact$ = createEffect(() =>
    this.actions$.pipe(
      ofType(addContact),
      mergeMap(({ contact }) =>
        this.contactService.addContact(contact).pipe(
          map((newContact) => addContactSuccess({ contact: newContact }))
        )
      )
    )
  );

  constructor(
    private actions$: Actions,
    private contactService: ContactService
  ) {}
}
