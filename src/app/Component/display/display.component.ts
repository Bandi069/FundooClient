import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { NoteServicesService } from 'src/app/Service/note-services.service';
import { ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-display',
  templateUrl: './display.component.html',
  styleUrls: ['./display.component.scss']
})
export class DisplayComponent implements OnInit {

  allNotes:any=[];
  val=null;
  param:any;
  allLabels:any;
  col:boolean=true;
  bin:boolean=false;
  gridView:any;
  @Output() output: EventEmitter<any> = new EventEmitter();
  constructor(private noteservice : NoteServicesService,private activatedRoute:ActivatedRoute,private snackBar :MatSnackBar) { }

  ngOnInit() {
    this.getAllNotes();
   this.getLabels();
    this.activatedRoute.queryParams.subscribe(params => {
      this.param = params['page'];
      this.gridView = params['view'];
      console.log(this.gridView);
    });
  }

  getAllNotes()
  {
    this.noteservice.getAllNotes().subscribe(Response => {      
      console.log(Response);
      this.allNotes=Response;
    })
  }

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
      this.snackBar.open('Notes not deleted','',{duration :2000});
    })
}
 

}
