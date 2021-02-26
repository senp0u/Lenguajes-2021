package cr.ac.ucr.teleatlantico.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.jpa.repository.query.Procedure;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import cr.ac.ucr.teleatlantico.domain.Client;
import cr.ac.ucr.teleatlantico.domain.Issue;

import java.util.List;

@Repository
public interface IssueRepository extends JpaRepository<Issue, Integer>{


    @Query(value = "{call SelectIssueByIdClient(?1)}", nativeQuery = true)
    List<Issue> getIssueByIdClient(@Param("@ClientId") Integer ClientId);
    
    @Query(value = "SELECT c FROM Client c JOIN FETCH c.issues i JOIN FETCH i.service WHERE c.email = ?1")
    Client findByEmail(String email);

    @Procedure(name = "InsertIssue", procedureName = "dbo.InsertIssue")
	void saveSP(@Param("Description") String description, @Param("ServiceId") int serviceId, @Param("ClientEmail")String clientEmail);

    @Query(value = "{call GetLastInsertIssue()}", nativeQuery = true)
    Issue getLastInsertIssue();
	
}
