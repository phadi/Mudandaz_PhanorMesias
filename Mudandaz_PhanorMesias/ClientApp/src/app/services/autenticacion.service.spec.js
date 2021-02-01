"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var autenticacion_service_1 = require("./autenticacion.service");
describe('AutenticacionService', function () {
    beforeEach(function () { return testing_1.TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = testing_1.TestBed.get(autenticacion_service_1.AutenticacionService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=autenticacion.service.spec.js.map