import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Note } from 'src/app/models/notes.model';
import { NoteServicesService } from 'src/app/Service/note-services.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { UpdateNoteComponent } from '../update-note/update-note.component';
import { Collaborator } from 'src/app/models/collaborator.model';
import { CollaboratorService } from 'src/app/Service/collaborator.service';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss']
})
export class NotesComponent implements OnInit {

  @Input() note: any;
  @Input() labels: any;
  @Input() notes: Note = new Note();
  text: Note = new Note();
  @Input() collaborator: any;
  colla: Collaborator = new Collaborator();
  listofCollab: any = [];
  @Output() output: EventEmitter<any> = new EventEmitter();
  constructor(private noteService: NoteServicesService,
    private collaboratorservice: CollaboratorService,
    private snackBar: MatSnackBar, public dialog: MatDialog) { }

  ngOnInit() {
  }

  getOutput(value) {
    this.output.emit('ok');
    this.getAllCollaborator();
  }
  deleteLabel(id) {
    this.noteService.deleteLabel(id).subscribe((result) => {
      this.output.emit('done');
      console.log('result', result);
      this.snackBar.open('Label deleted', '', { duration: 2000, horizontalPosition: 'start' });
    },
      (error) => {
        this.output.emit('error');
        console.log('error', error);
      });
  }
  OnClicktoUpdate(note) {
    if (note.istrash != true) {
      const dialogRef = this.dialog.open(UpdateNoteComponent, {
        height: 'auto',
        width: '40%',
        data: { note: note },
        panelClass: 'custom-dialog-container',
      });
      dialogRef.afterClosed().subscribe(result => {
        if (result.updateData) {
          this.noteService.updateNote(result.updateData).subscribe(response => {
            this.output.emit("ok");
          });
        }
        else {
          this.output.emit("ok");
        }
      });
    }
    else {
      console.log("Unable to edit the trash note");
    }
  }


  deleteReminder(id) {
    // this.text.id = id;
    console.log(id);
    this.noteService.removeReminder(id).subscribe((result) => {
      console.log('result', result);
      this.snackBar.open('Reminder Deleted', '', { duration: 3000, horizontalPosition: 'start' });
      this.output.emit('done');
    },
      (error) => {
        this.output.emit('done');
        console.log('error', error);
      }
    );
  }
  getAllCollaborator() {
    this.collaboratorservice.getcollabs().subscribe(
      listofCollab => {
        this.listofCollab = listofCollab;
        console.log(this.listofCollab);
      });
  }
  }
