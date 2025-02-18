import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactListComponent } from './contacts/components/contact-list/contact-list.component';
import { ContactFormComponent } from './contacts/components/contact-form/contact-form.component';

const routes: Routes = [
  { path: '', component: ContactListComponent },
  { path: 'add-contact', component: ContactFormComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}