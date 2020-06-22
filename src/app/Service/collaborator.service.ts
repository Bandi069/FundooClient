import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CollaboratorService {
  header = {
    headers: new HttpHeaders()
      .set('Authorization',  `Bearer ${localStorage.Token}`)
  }
  constructor(private http : HttpClient) { }

  addCollaborator(col)
  {
    return this.http.post(environment.Url+'addColloborator',col,this.header);
  }
   deleteCollaborator(coldelete)
   {
     return this.http.put(environment.Url+'deleteCollaborator?id='+coldelete,null,this.header);
   }
   getcollabs(){
     return this.http.get(environment.Url+'getAllCollaborators',this.header);
   }
  
}
