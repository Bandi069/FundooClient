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

@Component({
  selector: 'app-icons',
  templateUrl: './icons.component.html',
  styleUrls: ['./icons.component.scss']
})
export class IconsComponent implements OnInit {
  @Input() param: any;
  @Input() notes: any;
  @Input() collabo:any;
  @Input() labels:any;
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
  constructor(private noteservice: NoteServicesService,
     private snackBar: MatSnackBar,
    public dialog: MatDialog,
    private collaborator : CollaboratorService) { }
  ngOnInit() {
    this.validatingForm = new FormGroup({
      required: new FormControl(null, Validators.required)
    });
  }
  getOutputNotes() {
    this.output.emit('done');
  }
  get input() { 
    return this.validatingForm.get('required'); }

  setColor(changeColor) {
    this.noteservice.setColor(this.notes.id, changeColor).subscribe((result) => {
      console.log(result);
      this.snackBar.open('Color changed ', '', { duration: 3000,horizontalPosition:'start' });
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
          this.snackBar.open('Note archived', 'Dismiss', { duration: 3000,horizontalPosition: 'start'   });
          this.getOutputNotes();
        });
      }
    }
    else {

    }
  }
  updateUnArchive() {
    if (this.notes.id != null) {
      this.noteservice.UnArchive(this.notes.id).subscribe((result) => {
        console.log('response', result);
        this.snackBar.open('Note Unarchived', '', { duration: 3000,horizontalPosition: 'start'  });
        this.getOutputNotes();
      })
    }
  }
  updateTrash() {
    if (this.notes.id != null) {
      this.noteservice.sendToTrash(this.notes.id).subscribe((result) => {
        console.log('response', result);
        this.snackBar.open('Note trashed', 'Dismiss', { duration: 3000,horizontalPosition: 'start' });
        this.getOutputNotes();
      },
        (error) => {
          console.log('error :', error);
          this.snackBar.open('error ', '', { duration: 2000,horizontalPosition: 'start' });
        }
      );
    }
  }
  restore() {
    console.log(this.notes.id);
    this.noteservice.restoreFromTrash(this.notes.id).subscribe((result) => {
      console.log('response', result);
      this.snackBar.open('Note restored ', '', { duration: 2000,horizontalPosition: 'start'});;
      this.getOutputNotes();
    },
      (error) => {
        console.log('error', error);
        this.snackBar.open('error in restoring', '', { duration: 2000 });
      });
  }

  deleteForever() {
    if (this.notes.id != null) {
      this.noteservice.deleteNote(this.notes.id).subscribe((result) => {
        console.log('response', result);
        this.snackBar.open('Forever Deleted', 'Dismiss', { duration: 2000,horizontalPosition: 'start' });
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
        this.snackBar.open('Note Remindered', '', { duration: 2000,horizontalPosition: 'start'});
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
  openCollabDialog(coll) {
    const dialog = this.dialog.open(CollaboratorComponent, {
      autoFocus: false,
      data: coll,
      panelClass:'Collaborator-Container'
    });
    dialog.afterClosed().subscribe(result => {
      console.log('dialog closed');
    });
  }
  onFileChanged(event) {
    this.selectedFile = event.target.files[0]
  }
  uploadFileToActivity() {
    debugger;
    const uploadData = new FormData();
    uploadData.append('myFile', this.selectedFile, this.selectedFile.name);
   this.noteservice.uploadImage(this.notes.id,uploadData).subscribe(data => {
     }, error => {
       console.log(error);
      });
  }
  colors = [
    [
      { color: "rgb(255,255,255)", name: "Default color" },
      { color: "rgb(242, 139, 130)", name: "Red" },
      { color: "rgb(251, 188, 4)", name: "Orange" },
      { color: "rgb(255, 244, 117)", name: "Yellow" }
    ],
    [
      { color: "rgb(204, 255, 144)", name: "Green" },
      { color: "rgb(167, 255, 235)", name: "Teal" },
      { color: "rgb(203, 240, 248)", name: "Blue" },
      { color: "rgb(174, 203, 250)", name: "Dark blue"}
    ],
    [
      { color: "rgb(215, 174, 251)", name: "Purple" },
      { color: "rgb(253, 207, 232)", name: "Pink" },
      { color: "rgb(230, 201, 168)", name: "Brown" },
      { color: "rgb(232, 234, 237)", name: "Gray" }
    ]
  ]
}
