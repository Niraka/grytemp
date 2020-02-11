Wdm.Gryphon.LocaleModule = function () {
    this.localeIdsByName = {};
    this.localesById = {};
    this.textDefinitionIdsByName = {};
    this.textDefinitionsById = {};
    this.textsByLocaleIdByTextDefinitionId = {};
};

Wdm.Gryphon.LocaleModule.prototype.addLocale = function (locale) {
    this.localeIdsByName[locale.getName()] = locale.getId();
    this.localesById[locale.getId()] = locale;
};

Wdm.Gryphon.LocaleModule.prototype.addTextDefinition = function (textDefinition) {
    this.textDefinitionIdsByName[textDefinition.getName()] = textDefinition.getId();
    this.textDefinitionsById[textDefinition.getId()] = textDefinition;
};

Wdm.Gryphon.LocaleModule.prototype.addText = function (text) {
    var textsbyTextDefinitionId = this.textsByLocaleIdByTextDefinitionId[text.getLocaleId()];
    if (typeof textsbyTextDefinitionId === "undefined") {
        textsbyTextDefinitionId = {};
        textsbyTextDefinitionId[text.getTextId()] = text;
        this.textsByLocaleIdByTextDefinitionId[text.getLocaleId()] = textsbyTextDefinitionId;
    } else {
        textsbyTextDefinitionId[text.getTextId()] = text;
    }
};

Wdm.Gryphon.LocaleModule.prototype.removeLocale = function (iLocaleId) {
    var locale = this.getLocaleById(iLocaleId);
    if (typeof locale === "undefined") {
        return;
    }

    delete this.localeIdsByName[locale.getName()];
    delete this.localesById[iLocaleId];
};

Wdm.Gryphon.LocaleModule.prototype.removeTextDefinition = function (iTextDefinitionId) {
    var definition = this.getTextDefinitionById(iTextDefinitionId);
    if (typeof definition === "undefined") {
        return;
    }

    delete this.textDefinitionIdsByName[definition.getName()];
    delete this.textDefinitionsById[iTextDefinitionId];
};

Wdm.Gryphon.LocaleModule.prototype.removeText = function (iLocaleId, iTextDefinitionId) {
    var textsbyTextDefinitionId = this.textsByLocaleIdByTextDefinitionId[iLocaleId];
    if (typeof textsbyTextDefinitionId === "undefined") {
        return;
    }

    delete textsbyTextDefinitionId[iTextDefinitionId];
};

Wdm.Gryphon.LocaleModule.prototype.getLocaleById = function (iLocaleId) {
    return this.localesById[iLocaleId];
};

Wdm.Gryphon.LocaleModule.prototype.getLocaleByName = function (sLocaleName) {
    return this.getLocaleById(this.localeIdsByName[sLocaleName]);
};

Wdm.Gryphon.LocaleModule.prototype.getTextDefinitionById = function (iTextDefinitionId) {
    return this.textDefinitionsById[iTextDefinitionId];
};

Wdm.Gryphon.LocaleModule.prototype.getTextDefinitionByName = function (sTextName) {
    return this.getTextDefinitionById(this.textDefinitionIdsByName[sTextName]);
};

Wdm.Gryphon.LocaleModule.prototype.getText = function (iLocaleId, iTextDefinitionId) {
    var textsbyTextDefinitionId = this.textsByLocaleIdByTextDefinitionId[iLocaleId];
    if (typeof textsbyTextDefinitionId === "undefined") {
        return;
    }

    return textsbyTextDefinitionId[iTextDefinitionId];
};