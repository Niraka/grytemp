Wdm.Gryphon.GroupModule = function () {
    this.groupIdsByName = {};
    this.groupsById = {};
};

Wdm.Gryphon.GroupModule.prototype.addGroup = function (group) {
    this.groupIdsByName[group.getName()] = group.getId();
    this.groupsById[group.getId()] = group;
};

Wdm.Gryphon.GroupModule.prototype.removeGroup = function (iGroupId) {
    var group = this.getGroupById(iGroupId);
    if (typeof group === "undefined") {
        return;
    }

    delete this.groupIdsByName[group.getName()];
    delete this.groupsById[group.getId()];
};

Wdm.Gryphon.GroupModule.prototype.getGroupById = function (iGroupId) {
    return this.groupsById[iGroupId];
};

Wdm.Gryphon.GroupModule.prototype.getGroupByName = function (sGroupName) {
    return this.getGroupById(this.groupIdsByName[sGroupName]);
};