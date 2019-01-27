var ModalDialog = Class.create({
    initialize: function (args) {
        this.modalForm = args.modalForm;
        this.onLoadedModal = args.onLoadedModal;
        this.onShowModal = args.onShowModal;
        this.onShownModal = args.onShownModal;
        this.onHideModal = args.onHideModal;
        this.onHiddenModal = args.onHiddenModal;

        this._wireEvents();
    },
    showDialog: function () {
        this.modalForm.modal('show');
    },
    hideDialog: function () {
        this.modalForm.modal('hide');
    },
    setHtmlData: function (html) {
        $('#' + $(this.modalForm).attr('id') + ' .modal-content').html(html);
    },
    _wireEvents: function () {
        this.modalForm.on('loaded', $.proxy(function () {
            if (this.onLoadedModal)
                this.onLoadedModal();
        }, this));

        this.modalForm.on('show.bs.modal', $.proxy(function () {
            if (this.onShowModal)
                this.onShowModal();
        }, this));

        this.modalForm.on('shown.bs.modal', $.proxy(function () {
            if (this.onShownModal)
                this.onShownModal();
        }, this));

        this.modalForm.on('hide.bs.modal', $.proxy(function () {
            if (this.onHideModal)
                this.onHideModal();
        }, this));

        this.modalForm.on('hidden.bs.modal', $.proxy(function () {
            if (this.onHiddenModal)
                this.onHiddenModal();
            $(this.modalForm).removeData('bs.modal');
            $('#' + $(this.modalForm).attr('id') + ' .modal-content').empty();
        }, this));
    },

    onLoadedModal: undefined,
    onShowModal: undefined,
    onShownModal: undefined,
    onHideModal: undefined,
    onHiddenModal: undefined
});