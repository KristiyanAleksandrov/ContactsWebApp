import { ApplicationConfig } from '@angular/core';
import { provideStore } from '@ngrx/store';
import { provideEffects } from '@ngrx/effects';
import { provideStoreDevtools } from '@ngrx/store-devtools';
import { contactReducer } from './contacts/store/contact.reducer';
import { ContactEffects } from './contacts/store/contact.effects';
import { provideHttpClient } from '@angular/common/http';
import { providePrimeNG } from 'primeng/config';
import Aura from '@primeng/themes/aura';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

export const appConfig: ApplicationConfig = {
  providers: [
    provideStore({ contact: contactReducer }),
    provideEffects([ContactEffects]),
    provideStoreDevtools({ maxAge: 25 }),
    provideHttpClient(),
    provideAnimationsAsync(),
    providePrimeNG({
      theme: {
          preset: Aura
      }
  })
  ],
};
