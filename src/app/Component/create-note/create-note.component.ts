import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { NoteServicesService } from 'src/app/Service/note-services.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Note } from 'src/app/models/notes.model';
import { CollaboratorComponent } from '../collaborator/collaborator.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-create-note',
  templateUrl: './create-note.component.html',
  styleUrls: ['./create-note.component.scss']
})
export class CreateNoteComponent implements OnInit {
  popup: boolean = false;
  notes: Note = new Note();
  @Input() note : any;
  @Input() reminder: any;
  @Input() label: any;
  noteColor: string;
  archive = 0;
  pin = 0;
  time = "8:00 AM";
  repeat = "daily";
  day = "Today";
  selectedFile: File

 
  @Output() output: EventEmitter<any> = new EventEmitter();
  constructor(private noteService: NoteServicesService,   public dialog: MatDialog,
    private snackBar: MatSnackBar, 
    private formBuilder: FormBuilder) { }

  ngOnInit() {
  }
  open() {
    this.popup = true;
  }
  createNote(title, description) {
    this.popup = false;
    if (title != "" || description != "") {
      this.notes.title = title;
      this.notes.description = description;
      this.notes.changeColor = this.noteColor;
      this.notes.pin = this.pin;
      this.notes.email=localStorage.getItem('Email');
         this.notes.archive = this.archive;
      this.notes.reminder = this.reminder;
      this.noteService.createNoteService(this.notes).subscribe((result) => {
        console.log(result);
        this.snackBar.open('New note successfully created', '', { duration: 2000,
          horizontalPosition: 'start', 
          panelClass: ['red-snackbar'] });
        this.afterSubmit();
        this.output.emit("ok");
      },
        (error) => {
          this.snackBar.open('New note not added', '', { duration: 2000 });
          console.log('error response', error);
        });
    }
    else {
      this.afterSubmit();
    }
  }
  onFileChanged(event) {
    this.selectedFile = event.target.files[0]
  }
  afterSubmit() {
    this.popup = false;
    this.noteColor = null;
    this.archive = 0;
  }
  setColor(changeColor) {
    this.noteColor = changeColor;
  }
  save(date) {
    let str: any;
    if (date != "") {
      let v = new Date(date);
      str = v.toDateString();
    }
    else str = this.day;
    this.reminder = str + " " + this.time;
  }

  close() {
    this.reminder = null;
  }
  
  addLabels(label){
    this.label=label;
  }

  closelabel() {
    this.label = null;
  }

  listOfColors = [
    [
      { color: "rgb(255,255,255)", name: "Default" },
      { color: "#f28b82", name: "Red" },
      { color: "#fbbc04", name: "Orange" },
       { color: "#fff475", name: "Yellow" },
     
    ],
    [
      { color: "#ccff90", name: "Green" },  
      { color: "#a7ffeb", name: "Teal" },
      { color: "#cbf0f8", name: "Blue" },
      { color: "#aecbfa", name: "Dark blue" }
    ],
    [
      { color: "#d7aefb", name: "Purple" },
      { color: "#fdcfe8", name: "Pink" },
      { color: "#e6c9a8", name: "Brown" },
      { color: "#e8eaed", name: "Gray" }
    ]
  ]
  isPin()
  {
    if(this.pin==0)
    {
      this.pin=1;
    }
    else{
      this.pin=0;
    }
  }
  isArchive() { 
    if (this.archive == 0) {
      this.archive = 1;
      this.snackBar.open('Note archived successfully', 'Dismiss', { duration: 2000,
        horizontalPosition: 'start' });
    }
    else {
      this.archive = 0;
      this.snackBar.open('Note UnArchived', 'Dismiss', { duration: 2000 });
    }
  }
  setTime(value) {
    this.time = value;
  }

  setRepitation(value) {
    this.repeat = value;
  }
  openCollabDialog(data){
    const dialog = this.dialog.open(CollaboratorComponent, {
      autoFocus: false,
     // data: coll,
      panelClass:'Collaborator-Container'
    });
    dialog.afterClosed().subscribe(result => {
      console.log('dialog closed');
    });
  }
}
