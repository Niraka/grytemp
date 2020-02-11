Wdm.Gryphon.Text = function (iTextId, iLocaleId, sValue) {
    this.iTextId = iTextId;
    this.iLocaleId = iLocaleId;
    this.sValue = sValue;
};

Wdm.Gryphon.Text.prototype.getTextId = function () {
    return this.iTextId;
};

Wdm.Gryphon.Text.prototype.getLocaleId = function () {
    return this.iLocaleId;
};

Wdm.Gryphon.Text.prototype.getValue = function () {
    return this.sValue;
};