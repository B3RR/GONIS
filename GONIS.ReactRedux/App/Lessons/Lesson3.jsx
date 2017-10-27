import React from 'react';
import "./Lesson3.css";

class Note extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        let style = { backgroundColor: this.props.color };
        return (<div className="l3-note" style={style}>
            <button onClick={this.props.onDelete}> x </button>
            {this.props.children}
        </div>);
    }

}

class NoteEditor extends React.Component {
    constructor(props) {
        super(props);
        this.state = { text: "" }
        this.handleTextChange = this.handleTextChange.bind(this);
        this.handleNoteAdd = this.handleNoteAdd.bind(this);
    }

    handleTextChange(event) {
        this.setState({ text: event.target.value });
    }

    handleNoteAdd() {
        let newNote = {
            id: Date.now(),
            color: 'yellow',
            text: this.state.text
        };
        this.state.text = "";
        this.props.onNoteAdd(newNote);
    }

    render() {
        return (<div className="l3-note-editor">
            <textarea className="l3-textarea" placeholder="Enter your text..."
                rows={5}
                value={this.state.text}
                onChange={this.handleTextChange}
            />
            <button className=".l3-add-button" onClick={this.handleNoteAdd}>Add</button>
        </div>);
    }
}

class NotesGrid extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        let onNoteDelete = this.props.onNoteDelete;
        return (<div className="l3-notes-grid">
            {
                this.props.notes.map((note) => {
                    return <Note
                        key={note.id}
                        onDelete={onNoteDelete.bind(null,note)}
                        color={note.color}>
                        {note.text}
                    </Note>;
                })
            }
            
            </div>);
    }
}

export default class NotesApp extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            notes: [{
                id: 1,
                text: "First text text text text text text",
                color: "#FFD700"
            },
            {
                id: 2,
                text: "Second text text text text text text text text text text text text text text text text text text text text text text text text",
                color: "#20B2AA"
            },
            {
                id: 3,
                text: "Thrid text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text",
                color: "#5F9EA0"
            },
            {
                id: 4,
                text: "Four text text tex text text text text text text text text text text text text text text text text text text text text text text text text text text text text",
                color: "#6B8EB0"
            }]
        }
        this.handleNoteAdd = this.handleNoteAdd.bind(this);
        this._updateLocalStorage = this._updateLocalStorage.bind(this);
        this.handleNoteDelete = this.handleNoteDelete.bind(this);
    }

    componentDidMount() {
        let localNotes = JSON.parse(localStorage.getItem('notes'));
        if (localNotes) {
            this.setState({ notes: localNotes });
        }
    }

    handleNoteAdd(newNote) {
        let newNotes =  this.state.notes;
        newNotes.unshift(newNote);
        this.setState({ notes: newNotes });
    }
    componentDidUpdate() {
        this._updateLocalStorage()
    }

    _updateLocalStorage() {
        let notes = JSON.stringify(this.state.notes);
        localStorage.setItem('notes', notes);
    }
    handleNoteDelete(note)  {
        let noteId = note.id;
        var newNotes = this.state.notes.filter((note) => {
            return note.id !== noteId;
        }
        );
        this.setState({ notes: newNotes });
    }

    render() {
        return (<div className="l3-notes-app">
            <NoteEditor onNoteAdd={this.handleNoteAdd} />
            <NotesGrid notes={this.state.notes} onNoteDelete={this.handleNoteDelete} />

        </div>);
    }
}
