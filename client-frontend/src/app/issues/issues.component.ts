import { Component, OnInit, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import { RestService } from '../rest.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-issues',
  templateUrl: './issues.component.html',
  styleUrls: ['./issues.component.css']
})
export class IssuesComponent implements OnInit {

  issueForm: FormGroup;
  errorMessage: any;
  displayedColumns: string[] = ['issueId', 'service', 'status', 'supporterUser', 'description', 'query'];
  dataSource = new MatTableDataSource<any>();
  element:any=[];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  services:any=[];
  client:any;


  constructor(public rest:RestService, private fb: FormBuilder, private route: ActivatedRoute,
    private router: Router) {
      if(!rest.isLoggedIn()){
        this.router.navigate(['/sign-in']);
      }
      this.issueForm = this.fb.group({
        issueId: 0,
        description: new FormControl('', [
          Validators.required,
          Validators.pattern('^[A-Za-z0-9ñÑáéíóúÁÉÍÓÚ\\s]{10,100}$')
        ]),
        service: new FormControl('', [
          Validators.required
        ]),
        status: "Ingresado",
        supporterUser: "Por definir",
        createBy: "",
        createAt: "",
        modifyBy: "",
        modifyAt: ""
    })

}
ngOnInit() {
    this.rest.getClientByEmail().subscribe((data: {}) => {
    this.element = data;
    this.dataSource.paginator = this.paginator;
    this.getIssues();
    this.getServices();
  });
}
   
  getIssues(){
    
    this.dataSource.data=(this.element)
  }


  getServices(){
    this.services=[];
    this.rest.getServices().subscribe((data:{})=>{
    this.services=data;
    });
  }

  add() {
    
    if (!this.issueForm.valid) {
      return;
    }
    
    
    let issue = this.issueForm.value;
    console.log(this.issueForm.value.service.serviceId);
    issue.createBy = this.client.clientId+"-"+this.client.name;
    issue.createAt = new Date();
    this.client.issues.push(issue);

    this.rest.addIssue(this.client).subscribe((result) => {
      this.ngOnInit();
    }, (err) => {
      console.log(err);
    });
    
  }
}