Wdm.Gryphon.TextDefinition = function (iId, sName, sDescription) {
    this.iId = iId; 
    this.sName = sName;
    this.sDescription = sDescription;
};

Wdm.Gryphon.TextDefinition.prototype.getId = function () {
    return this.iId;
};

Wdm.Gryphon.TextDefinition.prototype.getName = function () {
    return this.sName;
};

Wdm.Gryphon.TextDefinition.prototype.getDescription = function () {
    return this.sDescription;
};