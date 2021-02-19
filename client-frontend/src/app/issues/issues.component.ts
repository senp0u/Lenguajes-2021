import {AfterViewInit, Component, ViewChild} from '@angular/core';
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
export class IssuesComponent implements AfterViewInit {

  issueForm: FormGroup;
  errorMessage: any;
  displayedColumns: string[] = ['issueId', 'servicet', 'status', 'supporterUser', 'descripIssue', 'query'];
  dataSource = new MatTableDataSource<any>();
  element:any=[];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  service:any=[];


  constructor(public rest:RestService, private fb: FormBuilder, private route: ActivatedRoute,
    private router: Router) {
    

      this.issueForm = this.fb.group({
        issueId: 0,
        description: new FormControl('', [
          Validators.required,
          Validators.pattern('^[A-Za-z0-9ñÑáéíóúÁÉÍÓÚ\\s]{10,100}$')
        ]),
        services: new FormControl('', [
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
  

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.getIssues();
  }

  getIssues(){
    this.element=[];
    this.rest.getIssues().subscribe((data:{})=>{
    this.element=data;
    this.dataSource.data=(this.element)
    console.log(this.element);

    });
  }

  getServices(){
    this.service=[];
    this.rest.getServices().subscribe((data:{})=>{
    this.service=data;
    this.dataSource.data=(this.service)
    console.log(this.service);

    });
  }

  add() {
    
    if (!this.issueForm.valid) {
      return;
    }
    
    this.rest.addIssue(this.issueForm.value).subscribe((result) => {
      this.router.navigate(['/issues']);
    }, (err) => {
      console.log(err);
    });
    
  }
}