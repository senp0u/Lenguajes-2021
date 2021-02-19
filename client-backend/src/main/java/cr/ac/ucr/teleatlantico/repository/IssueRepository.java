package cr.ac.ucr.teleatlantico.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import cr.ac.ucr.teleatlantico.domain.Issue;

@Repository
public interface IssueRepository extends JpaRepository<Issue, Integer>{
	
	@Query(value = "{ call SelectIssueByIdClient(?1)}", nativeQuery = true)
    Issue getIssueByIdClient(@Param("@ClientId") Integer ClientId);
}
