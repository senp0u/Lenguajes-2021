package cr.ac.ucr.teleatlantico.controller;

import cr.ac.ucr.teleatlantico.domain.Service;
import cr.ac.ucr.teleatlantico.service.ServiceService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import java.util.List;
@CrossOrigin(origins = "http://localhost:4200")
@RestController
@RequestMapping("/service")
public class ServiceController {
    @Autowired
    private ServiceService service;
    @GetMapping("/get")
    public List<Service> list() {
        return service.getAllServices();
    }
}