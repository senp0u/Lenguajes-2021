package cr.ac.ucr.teleatlantico.service;

import cr.ac.ucr.teleatlantico.domain.Service;
import cr.ac.ucr.teleatlantico.repository.ServiceRepository;
import org.springframework.beans.factory.annotation.Autowired;

import java.util.List;

@org.springframework.stereotype.Service

public class ServiceService {
    @Autowired
    private ServiceRepository repository;
    public List<Service> getAllServices() {
        return repository.findAll();
    }
}