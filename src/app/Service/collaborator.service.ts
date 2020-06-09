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
   deleteCollaborator(del)
   {
     return this.http.put(environment.Url+'deleteCollaborator?id='+del,null,this.header);
   }
   getcollabs(coll){
     return this.http.get(environment.Url+'getAllCollaborators'+coll,this.header);
   }
}
