import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { LabelComponent } from '../label/label.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { NoteServicesService } from 'src/app/Service/note-services.service';
import { CollaboratorService } from 'src/app/Service/collaborator.service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-collaborator',
  templateUrl: './collaborator.component.html',
  styleUrls: ['./collaborator.component.scss']
})
export class CollaboratorComponent implements OnInit {
  ownerimg: any = "";
  email: any = "";
  firstName: any = "";
  lastName: any = "";
  total: Number = 0;
  noteData : any ;
  collaborator : any;
  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<CollaboratorComponent>,
    private serviceobj: NoteServicesService,
    private collab: CollaboratorService,
    private snackBar: MatSnackBar) {  var user=JSON.parse(localStorage.getItem('userdata'));
    if(user!=undefined||user!=null){
      this.ownerimg=user.img;
      console.log("",this.ownerimg);
      this.email=user.email;
      this.firstName = user.firstName;
       this.lastName = user.lastName;
       this.noteData = data;
       console.log("data at collaborator",data.collaborator);
       this.collaborator = data.collaborator;} }

  ngOnInit() {
  }
  opp = new FormControl();
  gets: any = "";
  totalperson(total){
    if (total > 2 && this.opp.value){
      this.collab.getcollabs(total).subscribe(data=>{
        console.log("received response: ", data);
          this.gets = (data as any).message;
      },error=>{
        console.log("received error: ", error);
      })
    }
  }
  addcoloborator(get){
    console.log("user: ",get);
    const addCollaborator = {
    'noteId' : this.noteData.note._id,
    'senderemail' :get.email,
    'receveremail': localStorage.getItem('receveremail')
    }
    const addDataToArray = {
      'firstName':get.firstName,
      'lastName':get.lastName,
      'email':get.email
    }
    this.collab.addCollaborator(addCollaborator).subscribe(data=>{
      this.collaborator.push(addDataToArray);
    },
    error=>{
      console.log(error);
    })
  }
  deleteCollaborator(note){
    var Data = {
      'collaboratorId':note.id,
      'noteId':this.noteData.note.id
    }
    this.collab.deleteCollaborator(Data).subscribe(data=>{
      this.snackBar.open("collaborator deleted","done",{duration:2000});
      var index;
      for(let i = 0; i < this.collaborator.length ; i++){
        if(this.collaborator[i]._id == note.id){
           index = this.collaborator[i].id.indexOf(this.collaborator[i].id);  
        }
      }
      this.collaborator.splice(index, 1);
    },error=>{
      this.snackBar.open("not delete","",{duration:2000});
    })
  }
}

