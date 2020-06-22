import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class NoteServicesService {
  header = {
    headers: new HttpHeaders()
      .set('Authorization', `Bearer ${localStorage.Token}`)
  }
  constructor(private http: HttpClient) { }

  createNoteService(params) {
    var header = {
      headers: new HttpHeaders()
        .set('Authorization', `Bearer ${localStorage.Token}`)
    }
    return this.http.post(environment.Url + 'addnote', params, header);
  }

  getAllNotes() {
    return this.http.get(environment.Url + 'getNote', this.header);
  }

  Archive(arr) {
    console.log(arr);

    return this.http.put(environment.Url + 'isArchive?id=' + arr, null, this.header);
  }
  UnArchive(arr) {
    return this.http.put(environment.Url + 'unArchive?id=' + arr, null, this.header);
  }
  sendToTrash(param) {
    return this.http.put(environment.Url + 'trash?id=' + param, null, this.header);
  }
  restoreFromTrash(param) {
    return this.http.put(environment.Url + 'restore?id=' + param, null, this.header);
  }
  showTrashList() {
    return this.http.get(environment.Url + 'trashList', this.header);
  }
  emptyTrash() {
    return this.http.delete(environment.Url + 'emptyTrash', this.header);
  }
  deleteNote(id) {
    return this.http.put(environment.Url + 'deleteNote?id=' + id, null, this.header);
  }
  uploadImage(id, image) {
    debugger;
   // return this.http.post(environment.Url + 'uploadImage?image=', null, this.header);

    return this.http.post(environment.Url + 'uploadImage?image=' + image + '&id=' + id, null, this.header);
  }
  restoreAll() {
    return this.http.put(environment.Url + 'restoreAll', this.header);
  }
  getArchiveList() {
    return this.http.get(environment.Url + 'archiveList', this.header);
  }
  updatePin(note) {
    return this.http.put(environment.Url + 'isPin?id=' + note, null, this.header);
  }
  notesearch(values) {
    return this.http.get(environment.Url + 'search?searchParameter=' + values, this.header);
  }
  updateUnPin(note) {
    return this.http.put(environment.Url + 'unPin?id=' + note, null, this.header);
  }
  setReminder(id, reminder) {

    return this.http.put(environment.Url + 'reminder?id=' + id + '&reminder=' + reminder, null, this.header);
  }
  removeReminder(id) {
    return this.http.put(environment.Url + 'deleteReminder?id=' + id, null, this.header);
  }
  setColor(id, color) {
    console.log(id + color);
    return this.http.put(environment.Url + 'changeColor?id=' + id + '&changeColor=' + color, null, this.header);
  }
  addLabel(values) {
    return this.http.post(environment.Url + 'addLabel', values, this.header);
  }
  deleteLabel(id) {
    return this.http.put(environment.Url + 'deleteLabel?id=' + id, null, this.header);
  }
  getLabels() {
    return this.http.get(environment.Url + 'getAllLabels', this.header);
  }
  updateNote(obj) {
    return this.http.put(environment.Url + 'updateNote', obj, this.header);
  }
}
