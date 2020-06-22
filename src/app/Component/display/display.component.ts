import { Component, OnInit, EventEmitter, Output,Input } from '@angular/core';
import { NoteServicesService } from 'src/app/Service/note-services.service';
import { ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Collaborator } from 'src/app/models/collaborator.model';
import { CollaboratorService } from 'src/app/Service/collaborator.service';

@Component({
  selector: 'app-display',
  templateUrl: './display.component.html',
  styleUrls: ['./display.component.scss']
})
export class DisplayComponent implements OnInit {
  @Input() labels:any;
  allNotes:any=[];
  val=null;
  param:any;
  allLabels:any;
  col:boolean=true;
  bin:boolean=false;
  gridView:any;
  allColl:any;
  @Output() output: EventEmitter<any> = new EventEmitter();
  @Input() collaborator:any;
  colla :Collaborator=new Collaborator();
  listofCollab:any;
  constructor(private noteservice : NoteServicesService,private activatedRoute:ActivatedRoute,
    private collaboratorservice:CollaboratorService, private snackBar :MatSnackBar) { }

  ngOnInit() {
    this.getAllNotes();
     this.getLabels();
     this.getAllCollab();
    this.activatedRoute.queryParams.subscribe(params => {
      this.param = params['page'];
      this.gridView = params['view'];
      console.log(this.gridView);
    });
  }

  getAllCollab()
  {
    this.collaboratorservice.getcollabs().subscribe(Response=>
      {
        console.log(Response);
        this.allColl=Response;
      })
  }
  getAllNotes()
  {
    this.noteservice.getAllNotes().subscribe(Response => {      
      console.log(Response);
      this.allNotes=Response;
    })
  }
  // getAllCollaborator()
  // {
  //   this.collaboratorservice.getcollabs().subscribe(
  //     listofCollab=>{
  //       this.listofCollab=listofCollab;
  //       console.log(this.listofCollab);
  //     });
  // }
  getLabels() {
    this.noteservice.getLabels().subscribe(Response => {
      console.log(Response);
      this.allLabels = Response;
    });
  }

  getOutput(value){
    console.log(value);
    this.getAllNotes();
    this.getLabels();
    this.getAllCollab();
  }
emptyBin()
{
  this.bin=true;
  this.noteservice.emptyTrash().subscribe(Response=>
    {
      console.log("empty trash",Response);
      
      this.snackBar.open('Trash deleted','',{duration :2000,
        horizontalPosition: 'start'});
    },
    (error)=>{
      this.snackBar.open('Notes not deleted','',{duration :2000,horizontalPosition: 'start'});
    })
}
 

}
