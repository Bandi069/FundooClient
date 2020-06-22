import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, OnDestroy, OnInit, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Label } from 'src/app/models/label.model';
import { MatDialog } from '@angular/material/dialog';
import { LabelComponent } from '../label/label.component';
import { NoteServicesService } from 'src/app/Service/note-services.service';
import { ProfilePicComponent } from '../profile-pic/profile-pic.component';
import { AccountRegister } from 'src/app/models/account.model';
//import { DOCUMENT } from '@angular/common';
@Component({
  selector: 'app-dash-board',
  templateUrl: './dash-board.component.html',
  styleUrls: ['./dash-board.component.scss']
})
export class DashBoardComponent implements OnInit {
  view: boolean = false;
  grid = "row";
  allLabels: any;
  label: Label = new Label();
  labels: any;
  userData: any = " ";
  account :AccountRegister =new AccountRegister();
  firstName=localStorage.getItem('FirstName'); 
  email=localStorage.getItem('Email'); 
  constructor(private activatedRoute: ActivatedRoute, 
    private route: Router,
     public dialog: MatDialog,
      private noteService: NoteServicesService) { }
  ngOnInit(): void {
    this.getLabels();
  }

  gridView() {
    if (this.view == true) {
      this.view = false;
      this.grid = "row";
    }
    else {
      this.view = true;
      this.grid = "column";
    }
    this.activatedRoute.queryParams.subscribe(params => {
      let page = params['page'] || '';
      this.route.navigate(['dashboard/displaynote'], { queryParams: { page: page, view: this.grid } });
    });
  }
  
  notes() {
    this.route.navigate(['dashboard/displaynote'], { queryParams: { page: 'notes', view: this.grid } });
  }
  reminder() {
    this.route.navigate(['dashboard/displaynote'], { queryParams: { page: 'reminder' , view: this.grid} });
  }
  archive() {
    this.route.navigate(['dashboard/displaynote'], { queryParams: { page: 'archive' , view: this.grid} });
  }
  trash() {
    this.route.navigate(['dashboard/displaynote'], { queryParams: { page: 'trash' , view: this.grid} });
  }

  getLabels() {
    this.noteService.getLabels().subscribe(Response => {
      console.log(Response);
      this.allLabels = Response;
    });
  }
  labelOperation(labelName)
  {
    this.route.navigate(['dashboard/labels'], { queryParams: { page: labelName } });
  }
  search(value)
  {
    debugger;
    this.noteService.notesearch(value).subscribe((response)=>{
      debugger;
      console.log(response);
      this.route.navigate(['dashboard/search'], { queryParams: { data: value } });
   })
  }

  openDialog(allLabels) {
    const dialogRef = this.dialog.open(LabelComponent, {
      data: { labels: allLabels },
      panelClass: 'custom-dialog-container'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result.delteLabel) {
        this.noteService.deleteLabel(result.delteLabel).subscribe(response => {
          this.ngOnInit();
          console.log(response);
        });
      }
      else if (result.addLabel) {
        this.noteService.addLabel(result.addLabel).subscribe(response => {
          this.ngOnInit();
          console.log(response);
        });
      }
    });
  }
  ChangeProfile(){
    const dialogRef = this.dialog.open(ProfilePicComponent, {
      panelClass: 'profilepic-container'
    });
    dialogRef.afterClosed().subscribe(result => {
          console.log(result);
        });
      
  }
  logout() {
    localStorage.clear();
    this.route.navigate(['/login']);
  }
}