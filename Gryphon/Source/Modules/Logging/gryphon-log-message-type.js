Wdm.Gryphon.Log.MessageType = function (iId, sName, sDescription) {
    this.iId = iId;
    this.sName = sName;
    this.sDescription = sDescription;
};

Wdm.Gryphon.Log.MessageType.prototype.getId = function () {
    return this.iId;
};

Wdm.Gryphon.Log.MessageType.prototype.getName = function () {
    return this.sName;
};

Wdm.Gryphon.Log.MessageType.prototype.getDescription = function () {
    return this.sDescription;
};