package cr.ac.ucr.teleatlantico.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import cr.ac.ucr.teleatlantico.domain.Service;

@Repository
public interface ServiceRepository extends JpaRepository<Service, Integer>{



}
