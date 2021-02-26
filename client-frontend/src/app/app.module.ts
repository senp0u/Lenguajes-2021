//General
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule } from '@angular/common/http';
import {RouterModule, Routes } from '@angular/router'; 
import {FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

//Components
import { SignInComponent } from './sign-in/sign-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { IssuesComponent } from './issues/issues.component';

//Angular Material
import {MatCardModule} from '@angular/material/card';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatSortModule} from '@angular/material/sort';
import {MatButtonModule} from '@angular/material/button';
import {MatDividerModule} from '@angular/material/divider';
import {MatIconModule} from '@angular/material/icon';

const appRoutes: Routes = [
  {
    path: 'sign-in',
    component: SignInComponent,
    data: { title: 'Sign In' }
  },
  {
    path: 'sign-up',
    component: SignUpComponent,
    data: { title: 'Sign Up' }
  },
  {
    path: 'issues',
    component: IssuesComponent,
    data: { title: 'Issues' }
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
    SignInComponent,
    SignUpComponent,
    IssuesComponent
  ],
  imports: [
    RouterModule.forRoot(appRoutes),
    FormsModule,
    ReactiveFormsModule, 
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatCardModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatButtonModule,
    MatDividerModule,
    MatIconModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
