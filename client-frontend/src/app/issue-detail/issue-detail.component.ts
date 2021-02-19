import {AfterViewInit, Component, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import { RestService } from '../rest.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-issue-detail',
  templateUrl: './issue-detail.component.html',
  styleUrls: ['./issue-detail.component.css']
})
export class IssueDetailComponent implements AfterViewInit {

  noteForm: FormGroup;
  errorMessage: any;
  displayedColumns: string[] = ['note', 'response'];
  dataSource = new MatTableDataSource<any>();
  element:any=[];
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(public rest:RestService, private fb: FormBuilder, private route: ActivatedRoute,
    private router: Router) {
    

      this.noteForm = this.fb.group({
        noteId: 0,
        note: new FormControl('', [
          Validators.required,
          Validators.pattern('^[A-Za-z0-9ñÑáéíóúÁÉÍÓÚ\\s]{10,100}$')
        ])
    })

}

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.getNotes();
  }

  getNotes(){
    this.element=[];
    this.rest.getNotes().subscribe((data:{})=>{
    this.element=data;
    this.dataSource.data=(this.element)
    console.log(this.element);

    });
  }

  add() {
    
    if (!this.noteForm.valid) {
      return;
    }
    
    this.rest.addNote(this.noteForm.value).subscribe((result) => {
      this.router.navigate(['/issue-detail']);
    }, (err) => {
      console.log(err);
    });
    
  }

}
