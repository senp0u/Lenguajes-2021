import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { RestService } from '../rest.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  loginForm: FormGroup;
  errorMessage: any;
  showMsgError: boolean = false;
  showMsgRegistration: boolean = false;

  constructor(public rest:RestService, private fb: FormBuilder, private route: ActivatedRoute,
    private router: Router) {}

  ngOnInit(): void {

    if(this.route.snapshot.queryParamMap.get('showMsgRegistration')){
      this.showMsgRegistration= true;
    }

    this.loginForm = this.fb.group({
      email: new FormControl('', [
        Validators.required,
        Validators.email
      ]),
      password: new FormControl('', [
        Validators.required,
        Validators.pattern('^[A-Za-z0-9ñÑáéíóúÁÉÍÓÚ]{5,15}$')
      ])
  })
  }

  login() {
    
    if (!this.loginForm.valid) {
      return;
    }
    
    this.rest.login(this.loginForm.value.email, this.loginForm.value.password).subscribe((result) => {
        this.router.navigate(['/issues']);
    }, (err) => {
      this.showMsgError= true;
      this.showMsgRegistration= false;
    });
    
  }

}
