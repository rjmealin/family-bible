class AddHyperlinkDialog extends HTMLElement {
    constructor() {
        super();
        
    }

    connectedCallback() {
        this.shadowRoot.querySelector('.close').addEventListener('click', () => this.close());
        this.shadowRoot.querySelector('#add').addEventListener('click', () => this.add());
    }

    open() {
        this.shadowRoot.querySelector('#dialog').style.display = 'block';
    }

    close() {
        this.shadowRoot.querySelector('#dialog').style.display = 'none';
    }

    add() {
        const url = this.shadowRoot.querySelector('#url').value;
        this.dispatchEvent(new CustomEvent('add', { detail: { url } }));
        this.close();
    }
}