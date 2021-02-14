package cr.ac.ucr.teleatlantico.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import cr.ac.ucr.teleatlantico.domain.Client;

@Repository
public interface ClientRepository extends JpaRepository<Client, Integer>{

}
