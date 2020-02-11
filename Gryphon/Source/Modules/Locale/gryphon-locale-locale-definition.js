Wdm.Gryphon.LocaleDefinition = function (iId, sName, sCode, sFamilyName, sLocalisedName) {
    this.iId = iId;
    this.sName = sName;
    this.sCode = sCode;
    this.sFamilyName = sFamilyName;
    this.sLocalisedName = sLocalisedName;
};

Wdm.Gryphon.LocaleDefinition.prototype.getId = function () {
    return this.iId;
};

Wdm.Gryphon.LocaleDefinition.prototype.getName = function () {
    return this.sName;
};

Wdm.Gryphon.LocaleDefinition.prototype.getCode = function () {
    return this.sCode;
};

Wdm.Gryphon.LocaleDefinition.prototype.getFamilyName = function () {
    return this.sFamilyName;
};

Wdm.Gryphon.LocaleDefinition.prototype.getLocalisedName = function () {
    return this.sLocalisedName;
};