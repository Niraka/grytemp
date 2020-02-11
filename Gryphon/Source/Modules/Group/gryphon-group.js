Wdm.Gryphon.Group = function (iId, sName, sDescription, memberIds) {
    this.iId = iId;
    this.sName = sName;
    this.sDescription = sDescription;
    this.memberIds = memberIds;
};

Wdm.Gryphon.Group.prototype.getId = function () {
    return this.iId;
};

Wdm.Gryphon.Group.prototype.getName = function () {
    return this.sName;
};

Wdm.Gryphon.Group.prototype.getDescription = function () {
    return this.sDescription;
};

Wdm.Gryphon.Group.prototype.getMemberIds = function () {
    return this.memberIds;
};