import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { MessageService } from 'primeng/api';
import { selectContactError } from '../contacts/store/contact.selectors';
import { clearError } from '../contacts/store/contact.actions';

@Component({
  selector: 'app-global-error-handler',
  template: '',
})
export class GlobalErrorHandlerComponent implements OnInit {
  error$: Observable<string | null>;

  constructor(private store: Store, private messageService: MessageService) {
    this.error$ = this.store.select(selectContactError);
  }

  ngOnInit() {
    this.error$.subscribe((error) => {
      if (error) {
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: error,
          life: 10000,
        });
      }

      this.store.dispatch(clearError());
    });
  }
}
