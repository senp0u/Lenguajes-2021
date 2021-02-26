import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { RestService } from '../rest.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  clientForm: FormGroup;
  errorMessage: any;
  showMsgError: boolean = false;

  constructor(public rest:RestService, private fb: FormBuilder, private route: ActivatedRoute,
    private router: Router) {
    

      this.clientForm = this.fb.group({
        clientId: 0,
        name: new FormControl('', [
          Validators.required,
          Validators.pattern('^[A-Za-zñÑáéíóúÁÉÍÓÚ\\s]{3,25}$')
        ]),
        firstSurname: new FormControl('', [
          Validators.required,
          Validators.pattern('^[A-Za-zñÑáéíóúÁÉÍÓÚ]{3,20}$')
        ]),
        secondSurname: new FormControl('', [
          Validators.required,
          Validators.pattern('^[A-Za-zñÑáéíóúÁÉÍÓÚ]{3,20}$')
        ]),
        address: new FormControl('', [
          Validators.required,
          Validators.pattern('^[A-Za-z0-9ñÑáéíóúÁÉÍÓÚ\\s]{10,40}$')
        ]),
        phone: new FormControl('', [
          Validators.required,
          Validators.pattern('^[0-9\\s]{8,15}$')
        ]),
        secondContact: new FormControl('', [
          Validators.pattern('^[0-9\\s]{8,15}$')
        ]),
        email: new FormControl('', [
          Validators.required,
          Validators.email
        ]),
        password: new FormControl('', [
          Validators.required,
          Validators.pattern('^[A-Za-z0-9ñÑáéíóúÁÉÍÓÚ\\s]{5,15}$')
        ]),
        createBy: "",
        createAt: "",
        modifyBy: "",
        modifyAt: ""
    })

}

  ngOnInit(): void {
  }

  add() {
    
    if (!this.clientForm.valid) {
      return;
    }
    
    this.rest.addClient(this.clientForm.value).subscribe((result) => {
      let showMsgRegistration = true;
      this.router.navigate(['/sign-in'], {queryParams: { showMsgRegistration } });
    }, (err) => {
      this.showMsgError= true;
    });
    
  }
}