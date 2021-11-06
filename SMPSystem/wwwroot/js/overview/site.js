function BoxConfirm(boxmessage, uri, event) {
    event.preventDefault();
    bootbox.confirm({
        closeButton: false,
        message: boxmessage,
        className: '',
        buttons: {
            confirm: { label: 'Sim', className: 'btn-primary' },
            cancel: { label: 'Não', className: 'c-btn-secondary' }
        },
        callback: function (result) {
            if (result) location.href = uri;
        }
    });
}