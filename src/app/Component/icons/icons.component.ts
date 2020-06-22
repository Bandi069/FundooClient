import { Component, OnInit, Input, EventEmitter, Output, Inject } from '@angular/core';
import { Note } from 'src/app/models/notes.model';
import { NoteServicesService } from 'src/app/Service/note-services.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Label } from 'src/app/models/label.model';
import { CollaboratorComponent } from '../collaborator/collaborator.component';
import { FormGroup, FormControl, Validators } from '@angular/forms';
//import { CollaboratorModel } from 'src/app/models/collaborator.model';
import { CollaboratorService } from 'src/app/Service/collaborator.service';
import { Container } from '@angular/compiler/src/i18n/i18n_ast';
import { Collaborator } from 'src/app/models/collaborator.model';

@Component({
  selector: 'app-icons',
  templateUrl: './icons.component.html',
  styleUrls: ['./icons.component.scss']
})
export class IconsComponent implements OnInit {
  @Input() param: any;
  @Input() notes: any;
  @Input() collabo: any;
  @Input() labels: any;
  label: Label = new Label();
  checked = false;
  indeterminate = false;
  labelPosition = 'after';
  disabled = false;
  selectedFile: File
  @Output() output: EventEmitter<any> = new EventEmitter();
  note: Note = new Note();
  //colla :Collaborator=new Collaborator();
  time = "8:00 AM";
  repeat = "daily";
  reminder: Note = new Note();
  day = "Today";
  validatingForm: FormGroup;
  todayString: string = new Date().toDateString();
  colla: Collaborator = new Collaborator();
  timer = new FormControl('');
  constructor(private noteservice: NoteServicesService,
    private snackBar: MatSnackBar,
    public dialog: MatDialog,
    private collaborator: CollaboratorService) { }
  ngOnInit() {
    this.validatingForm = new FormGroup({
      required: new FormControl(null, Validators.required)
    });
  }
  getOutputNotes() {
    this.output.emit('done');
  }
  get input() {
    return this.validatingForm.get('required');
  }

  setColor(changeColor) {
    this.noteservice.setColor(this.notes.id, changeColor).subscribe((result) => {
      console.log(result);
      this.snackBar.open('Color changed ', '', { duration: 3000, horizontalPosition: 'start' });
      this.getOutputNotes();
    },
      (error) => {
        console.log('error respons', error);
        this.snackBar.open('error ', 'Dismiss', { duration: 3000 });
      });

  }

  setRepitation(repeat) {
    this.repeat = repeat;
  }

  setTime(time) {
    this.time = time;
  }
  updateArchive() {
    if (this.notes.id != null) {
      if (this.notes.archive == 0) {
        this.noteservice.Archive(this.notes.id).subscribe(result => {
          console.log(result);
          this.snackBar.open('Note archived', 'Dismiss', { duration: 3000, horizontalPosition: 'start' });
          this.getOutputNotes();
        });
      }
    }
    else {
      this.snackBar.open('Error in archived', 'Dismiss', { duration: 3000, horizontalPosition: 'start' });

    }
  }
  updateUnArchive() {
    if (this.notes.id != null) {
      this.noteservice.UnArchive(this.notes.id).subscribe((result) => {
        console.log('response', result);
        this.snackBar.open('Note Unarchived', '', { duration: 3000, horizontalPosition: 'start' });
        this.getOutputNotes();
      })
    }
  }
  onclickcheckBox() {

  }
  updateTrash() {
    if (this.notes.id != null) {
      this.noteservice.sendToTrash(this.notes.id).subscribe((result) => {
        console.log('response', result);
        this.snackBar.open('Note trashed', 'Dismiss', { duration: 3000, horizontalPosition: 'start' });
        this.getOutputNotes();
      },
        (error) => {
          console.log('error :', error);
          this.snackBar.open('error ', '', { duration: 2000, horizontalPosition: 'start' });
        }
      );
    }
  }
  restore() {
    console.log(this.notes.id);
    this.noteservice.restoreFromTrash(this.notes.id).subscribe((result) => {
      console.log('response', result);
      this.snackBar.open('Note restored ', '', { duration: 2000, horizontalPosition: 'start' });;
      this.getOutputNotes();
    },
      (error) => {
        console.log('Error', error);
        this.snackBar.open('Error in restoring', '', { duration: 2000 });
      });
  }

  deleteForever() {
    if (this.notes.id != null) {
      this.noteservice.deleteNote(this.notes.id).subscribe((result) => {
        console.log('response', result);
        this.snackBar.open('Forever Deleted', 'Dismiss', { duration: 2000, horizontalPosition: 'start' });
        this.getOutputNotes();
      },
        (error) => {
          console.log('error', error);
          this.snackBar.open('error in deleting', '', { duration: 2000 });
        });
    }
  }
  saveReminder(date) {
    let str: any;
    if (date != "") {
      let v = new Date(date);
      str = v.toDateString();
    }
    else str = this.day;
    let remin = str + " " + this.time;

    if (this.notes.id != undefined) {
      this.noteservice.setReminder(this.notes.id, remin).subscribe((result) => {
        console.log(result);
        console.log(this.notes.id, remin);
        this.getOutputNotes();
        this.snackBar.open('Note Remindered', '', { duration: 2000, horizontalPosition: 'start' });
      })
    }
  }
  newLabel(labelname) {
    if (labelname != null && labelname != '') {
      this.label.labelName = labelname;
      this.label.noteId = this.notes.id;
      // this.label.email=localStorage.getItem('Email');
      this.noteservice.addLabel(this.label).subscribe(Response => {
        console.log(Response);
        this.getOutputNotes();
      });
    }
  }

  openCollabDialog() {
    // debugger;
    this.colla.noteId = this.notes.id;
    // debugger;
    const dialogRef = this.dialog.open(CollaboratorComponent, {

      data: { collab: this.colla, collaborators: this.collabo },
      panelClass: 'Collaborator-Container'
    });
    dialogRef.afterClosed().subscribe(result => {
      //  debugger;
      console.log(result.collaborateData);
      if (result.collaborateData) {
        this.collaborator.addCollaborator(result.collaborateData).subscribe(Response => {
          console.log(Response);
          this.output.emit({ name: 'getAllNote' });
        });
      }

      else if (result.deleteCol) {
        this.collaborator.deleteCollaborator(result.deleteCol).subscribe(Response => {
          console.log(Response);
          this.output.emit({ name: 'getAllNote' });
        });
      }
      else {
        //debugger;
        if (result.collaborateData == undefined) {
          console.log('No collaborator added: error');
        }
      }
    });
  }

  onFileChanged(event) {
    this.selectedFile = event.target.files[0]
  }
  uploadFileToActivity() {
    debugger;
    const uploadData = new FormData();
    uploadData.append('myFile', this.selectedFile, this.selectedFile.name);
    this.noteservice.uploadImage(this.notes.id, uploadData).subscribe(data => {
    }, error => {
      console.log(error);
    });
  }
  colors = [
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
}
