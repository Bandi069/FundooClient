import { Component, OnInit, Inject, Input } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { LabelComponent } from '../label/label.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { NoteServicesService } from 'src/app/Service/note-services.service';
import { CollaboratorService } from 'src/app/Service/collaborator.service';
import { FormControl } from '@angular/forms';
import { Collaborator } from 'src/app/models/collaborator.model';
import { AccountRegister } from 'src/app/models/account.model';

@Component({
  selector: 'app-collaborator',
  templateUrl: './collaborator.component.html',
  styleUrls: ['./collaborator.component.scss']
})
export class CollaboratorComponent implements OnInit {

  colla: Collaborator = new Collaborator();
  account: AccountRegister = new AccountRegister();
  email = localStorage.getItem('Email');
 // name = localStorage.getItem('FullName');
  first=localStorage.getItem('FirstName');
  last=localStorage.getItem('LastName');
  @Input() notes: any;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<CollaboratorComponent>,
    private serviceobj: NoteServicesService,
    private collaborator: CollaboratorService,
    private snackBar: MatSnackBar) {
  }
  ngOnInit() {
  }

  addCollaborator(email, noteId) {
    debugger;
    console.log(email, noteId);
    this.colla.noteId = noteId;
    debugger;
    if (email != null && noteId != null) {
      this.colla.senderEmail = localStorage.getItem('Email');
      this.colla.receiverEmail = email;
      this.dialogRef.close({ collaborateData: this.colla });
    }
    else if (email != null && noteId == null) {
      this.dialogRef.close({ email: email });
    }
    else {
      console.log("error");
    }
  }
  deleteCollaborator(id) {
    debugger;
    this.colla.id = id
    this.dialogRef.close({ deleteCol: id });
  }

}

