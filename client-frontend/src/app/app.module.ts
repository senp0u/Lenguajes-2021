import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule } from '@angular/common/http';
import {RouterModule, Routes } from '@angular/router'; 

// Sign In
import { SignInComponent } from './sign-in/sign-in.component';
import {MatCardModule} from '@angular/material/card';
import {FormsModule, ReactiveFormsModule } from '@angular/forms';

const appRoutes: Routes = [
  {
    path: 'sign-in',
    component: SignInComponent,
    data: { title: 'Sign In' }
  },
  {
    path: '',
    redirectTo: '/sign-in',
    pathMatch: 'full'
  }

];

@NgModule({
  declarations: [
    AppComponent,
    SignInComponent
  ],
  imports: [
    RouterModule.forRoot(appRoutes),
    FormsModule,
    ReactiveFormsModule, 
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatCardModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
