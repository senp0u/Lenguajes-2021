import {AfterViewInit, Component, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import { RestService } from '../rest.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-issues',
  templateUrl: './issues.component.html',
  styleUrls: ['./issues.component.css']
})
export class IssuesComponent implements AfterViewInit {

  displayedColumns: string[] = ['issueId', 'description', 'status', 'supporterUser', 'query'];
  dataSource = new MatTableDataSource<any>();
  element:any=[];
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(public rest: RestService,  private route: ActivatedRoute,   private router: Router){}

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.getClients();
  }

  getClients(){
    this.element=[];
    this.rest.getClients().subscribe((data:{})=>{
    this.element=data;
    this.dataSource.data=(this.element)
    console.log(this.element);

    });
  }
}